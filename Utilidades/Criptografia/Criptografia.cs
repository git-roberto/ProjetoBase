using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public static class Criptografia
    {
        private static readonly string KEY = "rfeePKcPcf2dSL4unAIftSDh5E4a9oHOu7cU1l1Tz8M=";
                
        private static readonly string IV = "TmvZoTrR7vc6yho7ZKb8wg==";


        /// <summary>
        /// Método para Criptografia em MD5
        /// </summary>
        public static string CriptografarMD5(string texto)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(texto);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Método para Criptografia em SHA512
        /// </summary>
        public static string CriptografarSHA512(string texto)
        {
            using (SHA512 service = SHA512.Create())
            {
                byte[] bytes = service.ComputeHash(Encoding.UTF8.GetBytes(texto));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        /// <summary>
        /// Método para Criptografia em SHA256
        /// </summary>
        public static string CriptografarSHA256(string texto)
        {
            using (SHA256 service = SHA256.Create())
            {
                byte[] bytes = service.ComputeHash(Encoding.UTF8.GetBytes(texto));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Método para Criptografia em SHA1
        /// </summary>
        public static string CriptografarSHA1(string texto)
        {
            using (SHA1 service = SHA1.Create())
            {
                byte[] bytes = service.ComputeHash(Encoding.UTF8.GetBytes(texto));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string CodificarBase64Url(string data)
        {
            return CodificarBase64Url(Encoding.UTF8.GetBytes(data));
        }

        public static string DecodificarBase64Url(string base64)
        {
            string s = base64;
            s = s.Replace('-', '+'); // 62nd char of encoding
            s = s.Replace('_', '/'); // 63rd char of encoding
            switch (s.Length % 4) // Pad with trailing '='s
            {
                case 0: break; // No pad chars in this case
                case 2: s += "=="; break; // Two pad chars
                case 3: s += "="; break; // One pad char
                default:
                    throw new Exception("Valor informado não é base64!");
            }
            return Encoding.UTF8.GetString(Convert.FromBase64String(s)); // Standard base64 decoder
        }

        public static string CodificarBase64Url(byte[] data)
        {
            string s = Convert.ToBase64String(data); // Regular base64 encoder
            s = s.Split('=')[0]; // Remove any trailing '='s
            s = s.Replace('+', '-'); // 62nd char of encoding
            s = s.Replace('/', '_'); // 63rd char of encoding
            return s;
        }

        public static string DecodificarBase64Url(byte[] base64)
        {
            return DecodificarBase64Url(Encoding.UTF8.GetString(base64));
        }

        public static string Criptografar(string texto)
        {
            var retorno = CriptografarAES(texto, IV, KEY);

            return retorno;
        }

        public static string Descriptografar(string textoCripto)
        {
            var retorno = DescriptografarAES(textoCripto, IV, KEY);

            return retorno;
        }

        public static string CriptografarAES(string texto, string IV, string key)
        {
            Aes cipher = CreateCipher(key);
            cipher.IV = Convert.FromBase64String(IV);

            ICryptoTransform cryptTransform = cipher.CreateEncryptor();
            byte[] plaintext = Encoding.UTF8.GetBytes(texto);
            byte[] cipherText = cryptTransform.TransformFinalBlock(plaintext, 0, plaintext.Length);

            return Convert.ToBase64String(cipherText);
        }

        public static string DescriptografarAES(string criptoTexto, string IV, string key)
        {
            Aes cipher = CreateCipher(key);
            cipher.IV = Convert.FromBase64String(IV);

            ICryptoTransform cryptTransform = cipher.CreateDecryptor();
            byte[] encryptedBytes = Convert.FromBase64String(criptoTexto);
            byte[] plainBytes = cryptTransform.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

            return Encoding.UTF8.GetString(plainBytes);
        }

        public static (string Key, string IVBase64) InitSymmetricEncryptionKeyIV()
        {
            var key = GetEncodedRandomString(32); // 256
            Aes cipher = CreateCipher(key);
            var IVBase64 = Convert.ToBase64String(cipher.IV);
            return (key, IVBase64);
        }

        private static Aes CreateCipher(string keyBase64)
        {
            // Default values: Keysize 256, Padding PKC27
            Aes cipher = Aes.Create();
            cipher.Mode = CipherMode.CBC;  // Ensure the integrity of the ciphertext if using CBC

            cipher.Padding = PaddingMode.ISO10126;
            cipher.Key = Convert.FromBase64String(keyBase64);

            return cipher;
        }

        private static string GetEncodedRandomString(int tamanho)
        {
            var base64 = Convert.ToBase64String(GenerateRandomBytes(tamanho));
            return base64;
        }

        private static byte[] GenerateRandomBytes(int length)
        {
            var byteArray = new byte[length];
            RandomNumberGenerator.Fill(byteArray);
            return byteArray;
        }

        public static void CriptografarArquivo(string arquivoOrigem, string arquivoDestino, string senha)
        {
            //generate random salt
            byte[] salt = GenerateRandomBytes(32);

            FileStream fsCrypt = new FileStream(arquivoDestino, FileMode.Create);

            //convert password string to byte arrray
            byte[] passwordBytes = Encoding.UTF8.GetBytes(senha);

            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Padding = PaddingMode.PKCS7;

            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            AES.Mode = CipherMode.CFB;

            fsCrypt.Write(salt, 0, salt.Length);

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);

            FileStream fsIn = new FileStream(arquivoOrigem, FileMode.Open);

            //create a buffer (1mb) so only this amount will allocate in the memory and not the whole file
            byte[] buffer = new byte[1048576];
            int read;

            try
            {
                while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                {
                    cs.Write(buffer, 0, read);
                }

                // Close up
                fsIn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                cs.Close();
                fsCrypt.Close();
            }
        }

        public static void DescriptografarArquivo(string arquivoOrigem, string arquivoDestino, string senha)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(senha);
            byte[] salt = new byte[32];

            FileStream fsCrypt = new FileStream(arquivoOrigem, FileMode.Open);
            fsCrypt.Read(salt, 0, salt.Length);

            RijndaelManaged AES = new RijndaelManaged
            {
                KeySize = 256,
                BlockSize = 128
            };
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CFB;

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(arquivoDestino, FileMode.Create);

            int read;
            byte[] buffer = new byte[1048576];

            try
            {
                while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fsOut.Write(buffer, 0, read);
                }
            }
            catch (CryptographicException ex_CryptographicException)
            {
                throw new CryptographicException("CryptographicException: " + ex_CryptographicException.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }

            try
            {
                cs.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro para fechar o CryptoStream: " + ex.Message);
            }
            finally
            {
                fsOut.Close();
                fsCrypt.Close();
            }
        }

        public static byte[] DescriptografarArquivoArray(string arquivoOrigem, string senha)
        {
            byte[] retorno = null;
            byte[] passwordBytes = Encoding.UTF8.GetBytes(senha);
            byte[] salt = new byte[32];

            FileStream fsCrypt = new FileStream(arquivoOrigem, FileMode.Open);
            fsCrypt.Read(salt, 0, salt.Length);

            RijndaelManaged AES = new RijndaelManaged
            {
                KeySize = 256,
                BlockSize = 128
            };
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CFB;

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

            int read;
            byte[] buffer = new byte[1048576];

            try
            {
                using (var output = new MemoryStream())
                {
                    while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        output.Write(buffer, 0, read);
                        read = cs.Read(buffer, 0, buffer.Length);
                    }
                    cs.Flush();

                    retorno = output.ToArray();
                }
            }
            catch (CryptographicException ex_CryptographicException)
            {
                throw new CryptographicException("CryptographicException: " + ex_CryptographicException.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }

            try
            {
                cs.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro para fechar o CryptoStream: " + ex.Message);
            }
            finally
            {
                fsCrypt.Close();
            }

            return retorno;
        }

        public static void CriptografarArquivo(string arquivoOrigem, string arquivoDestino)
        {
            CriptografarArquivo(arquivoOrigem, arquivoDestino, KEY);
        }

        public static void DescriptografarArquivo(string arquivoOrigem, string arquivoDestino)
        {
            DescriptografarArquivo(arquivoOrigem, arquivoDestino, KEY);
        }

        public static byte[] DescriptografarArquivoArray(string arquivoOrigem)
        {
            return DescriptografarArquivoArray(arquivoOrigem, KEY);
        }
    }
}
