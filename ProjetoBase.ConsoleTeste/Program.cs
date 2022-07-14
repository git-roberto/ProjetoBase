

using Utilidades;

string texto = "server=localhost,1450;database=dbProjetoBase;uid=sa;password=Teste*123;";
string cripto = Criptografia.Criptografar(texto);
string descripto = Criptografia.Descriptografar(cripto);
string criptoMD5 = Criptografia.CriptografarMD5(texto);
string criptoSHA1 = Criptografia.CriptografarSHA1(texto);
string criptoSHA2 = Criptografia.CriptografarSHA256(texto);
string criptoSHA3 = Criptografia.CriptografarSHA512(texto);
string criptobase64 = Criptografia.CodificarBase64Url(texto);
string descriptobase64 = Criptografia.DecodificarBase64Url(criptobase64);

Console.WriteLine("Normal: " + texto);
Console.WriteLine("Cripto: " + cripto);
Console.WriteLine("DesCripto: " + descripto);
Console.WriteLine("criptoMD5: " + criptoMD5);
Console.WriteLine("criptoSHA1: " + criptoSHA1);
Console.WriteLine("criptoSHA2: " + criptoSHA2);
Console.WriteLine("criptoSHA3: " + criptoSHA3);
Console.WriteLine("criptobase64: " + criptobase64);
Console.WriteLine("descriptobase64: " + descriptobase64);

