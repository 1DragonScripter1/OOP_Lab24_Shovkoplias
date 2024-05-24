using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_24_Shovkoplias
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource ctsRedoc, ctsMdc2, ctsPkzip;

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Обробник подій кнопок
            btnStartRedoc.Click += (s, ev) => StartRedoc(textBoxRedoc);
            btnStopRedoc.Click += (s, ev) => StopRedoc();
            btnStartMdc2.Click += (s, ev) => StartMdc2(textBoxMdc2);
            btnStopMdc2.Click += (s, ev) => StopMdc2();
            btnStartPkzip.Click += (s, ev) => StartPkzip(textBoxPkzip);
            btnStopPkzip.Click += (s, ev) => StopPkzip();
            btnStartAll.Click += (s, ev) => { StartRedoc(textBoxRedoc); StartMdc2(textBoxMdc2); StartPkzip(textBoxPkzip); };
            btnStopAll.Click += (s, ev) => { StopRedoc(); StopMdc2(); StopPkzip(); };
        }

        private void StartRedoc(TextBox tb)
        {
            if (ctsRedoc == null || ctsRedoc.IsCancellationRequested)
            {
                ctsRedoc = new CancellationTokenSource();
                Task.Run(() => PerformRedocEncryption(ctsRedoc.Token, tb));
            }
        }

        private void StopRedoc()
        {
            if (ctsRedoc != null && !ctsRedoc.IsCancellationRequested)
            {
                ctsRedoc.Cancel();
            }
        }

        private void StartMdc2(TextBox tb)
        {
            if (ctsMdc2 == null || ctsMdc2.IsCancellationRequested)
            {
                ctsMdc2 = new CancellationTokenSource();
                Task.Run(() => PerformMdc2Hashing(ctsMdc2.Token, tb));
            }
        }

        private void StopMdc2()
        {
            if (ctsMdc2 != null && !ctsMdc2.IsCancellationRequested)
            {
                ctsMdc2.Cancel();
            }
        }

        private void StartPkzip(TextBox tb)
        {
            if (ctsPkzip == null || ctsPkzip.IsCancellationRequested)
            {
                ctsPkzip = new CancellationTokenSource();
                Task.Run(() => PerformPkzipEncryption(ctsPkzip.Token, tb));
            }
        }

        private void StopPkzip()
        {
            if (ctsPkzip != null && !ctsPkzip.IsCancellationRequested)
            {
                ctsPkzip.Cancel();
            }
        }

        private async Task PerformRedocEncryption(CancellationToken token, TextBox tb)
        {
            var rand = new Random();
            tb.Invoke(() => tb.Clear());

            while (!token.IsCancellationRequested)
            {
                string plaintext = GenerateRandomString(32, rand);
                string encrypted = EncryptREDOC(plaintext);

                tb.Invoke(() => tb.AppendText($"Original: {plaintext}\nEncrypted (REDOC): {encrypted}\n\n"));

                await Task.Delay(1000, token).ConfigureAwait(false);
            }
        }

        private async Task PerformMdc2Hashing(CancellationToken token, TextBox tb)
        {
            var rand = new Random();
            tb.Invoke(() => tb.Clear());

            while (!token.IsCancellationRequested)
            {
                string plaintext = GenerateRandomString(32, rand);
                string hash = ComputeMDC2(plaintext);

                tb.Invoke(() => tb.AppendText($"Original: {plaintext}\nMDC-2 Hash: {hash}\n\n"));

                await Task.Delay(1000, token).ConfigureAwait(false);
            }
        }

        private async Task PerformPkzipEncryption(CancellationToken token, TextBox tb)
        {
            var rand = new Random();
            tb.Invoke(() => tb.Clear());

            while (!token.IsCancellationRequested)
            {
                string plaintext = GenerateRandomString(32, rand);
                string encrypted = EncryptPKZIP(plaintext);

                tb.Invoke(() => tb.AppendText($"Original: {plaintext}\nEncrypted (PKZIP): {encrypted}\n\n"));

                await Task.Delay(1000, token).ConfigureAwait(false);
            }
        }

        private string EncryptREDOC(string plaintext)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(plaintext);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "");
            }
        }

        private string ComputeMDC2(string plaintext)
        {
            // Використовуємо MD5 замість MDC2, оскільки MDC-2 не підтримується безпосередньо
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(plaintext);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "");
            }
        }

        private string EncryptPKZIP(string plaintext)
        {
            using (var crc = new Crc32())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(plaintext);
                byte[] hashBytes = crc.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "");
            }
        }

        private string GenerateRandomString(int length, Random rand)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                sb.Append(chars[rand.Next(chars.Length)]);
            }

            return sb.ToString();
        }
    }

    // CRC32 Implementation
    public class Crc32 : HashAlgorithm
    {
        public const uint DefaultPolynomial = 0xedb88320;
        public const uint DefaultSeed = 0xffffffff;
        private static uint[] defaultTable;
        private readonly uint seed;
        private readonly uint[] table;
        private uint hash;

        public Crc32()
            : this(DefaultPolynomial, DefaultSeed)
        {
        }

        public Crc32(uint polynomial, uint seed)
        {
            if (defaultTable == null)
            {
                defaultTable = InitializeTable(polynomial);
            }

            this.table = defaultTable;
            this.seed = seed;
            Initialize();
        }

        public static uint ComputeChecksum(byte[] bytes)
        {
            return ComputeChecksum(DefaultPolynomial, DefaultSeed, bytes);
        }

        public static uint ComputeChecksum(uint polynomial, uint seed, byte[] bytes)
        {
            var table = InitializeTable(polynomial);
            uint crc = seed;
            foreach (var t in bytes)
            {
                byte b = t;
                unchecked
                {
                    crc = (crc >> 8) ^ table[(crc & 0xff) ^ b];
                }
            }
            return ~crc;
        }

        public static byte[] ComputeChecksumBytes(byte[] bytes)
        {
            return BitConverter.GetBytes(ComputeChecksum(bytes));
        }

        public override void Initialize()
        {
            hash = seed;
        }

        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            hash = ComputeHashCore(table, hash, array, ibStart, cbSize);
        }

        protected override byte[] HashFinal()
        {
            var hashBuffer = BitConverter.GetBytes(~hash);
            Array.Reverse(hashBuffer);
            return hashBuffer;
        }

        private static uint[] InitializeTable(uint polynomial)
        {
            var createTable = new uint[256];

            for (int i = 0; i < 256; i++)
            {
                uint entry = (uint)i;
                for (int j = 0; j < 8; j++)
                {
                    if ((entry & 1) == 1)
                    {
                        entry = (entry >> 1) ^ polynomial;
                    }
                    else
                    {
                        entry >>= 1;
                    }
                }
                createTable[i] = entry;
            }

            return createTable;
        }

        private static uint ComputeHashCore(uint[] table, uint seed, byte[] buffer, int start, int size)
        {
            uint crc = seed;
            for (int i = start; i < start + size; i++)
            {
                unchecked
                {
                    crc = (crc >> 8) ^ table[(crc & 0xff) ^ buffer[i]];
                }
            }
            return crc;
        }
    }

    static class Extensions
    {
        public static void Invoke(this Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new MethodInvoker(action));
            }
            else
            {
                action();
            }
        }
    }
}