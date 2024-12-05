using System;
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public void CreateTcpClient(string host)
{
    try
    {
        using (var tcpClient = new TcpClient(host, 443)) // Use port 443 for HTTPS
        using (var sslStream = new SslStream(tcpClient.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null))
        {
            sslStream.AuthenticateAsClient(host);
            Console.WriteLine("TCP client connected securely to: " + host);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
    }
}

// The following method is invoked by the RemoteCertificateValidationCallback delegate.
public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
{
    if (sslPolicyErrors == SslPolicyErrors.None)
        return true;

    Console.WriteLine("Certificate error: " + sslPolicyErrors);
    return false;
}
