using MailKit.Net.Smtp;
using System.Text;
using MimeKit;

namespace Easy.Admin.Application.Auth.Dtos
{
    public static class EmailSignIn
    {
        /// <summary>
        /// 登录验证码邮件
        /// </summary>
        /// <param name="email"></param>
        /// <param name="verificationCode"></param>
        //public static void SendVerificationEmail(string email, string verificationCode)
        //{
        //    try
        //    {
        //        MailMessage mail = new MailMessage();
        //        SmtpClient smtpServer = new SmtpClient("smtp.163.com"); // 设置 SMTP 服务器地址

        //        mail.From = new MailAddress("13293092695@163.com"); // 发件人邮箱
        //        mail.To.Add(email); // 收件人邮箱
        //        mail.Subject = "Verification Code for Registration"; // 邮件主题
        //        mail.Body = $"Your verification code is: {verificationCode}"; // 邮件内容

        //        smtpServer.Port = 465; // SMTP 端口号
        //        smtpServer.Credentials = new NetworkCredential("13293092695@163.com", "XMGGBWKRANPRXRVP"); // 发件人邮箱和密码
        //        smtpServer.EnableSsl = true; // 启用 SSL 加密

        //        smtpServer.Send(mail); // 发送邮件
        //    }
        //    catch (Exception ex)
        //    {
        //        // 发送邮件失败时的处理逻辑
        //        Console.WriteLine("Error sending email: " + ex.Message);
        //    }
        //}
        public static async Task SendVerificationEmail(string email, string verificationCode)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Verification Code", "13293092695@163.com"));
                message.To.Add(new MailboxAddress("", email));
                message.Subject = "Verification Code for Registration";
                message.Body = new TextPart("html")
                {
                    Text = $"Your verification code is: <strong>{verificationCode}</strong>"
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.163.com", 465, true);
                    await client.AuthenticateAsync("13293092695@163.com", "XMGGBWKRANPRXRVP");
                    await client.SendAsync(message);
                    client.Disconnect(true);
                    
                }

                
            }
            catch (Exception ex)
            {
                // 发送邮件失败时的处理逻辑
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }

        public static string GenerateVerificationCode()
        {
            Random random = new Random();
            const string chars = "0123456789";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                sb.Append(chars[random.Next(chars.Length)]);
            }
            return sb.ToString();
        }

    }
    public class UserModel
    {
        [Required(ErrorMessage = "请输入登录密码")]
        public string Email { get; set; }
    }
    public class Return
    {
        public string Email { get; internal set; }
    }

    public class Risuget { 
    
        public string Email { get; set; }

        public string Code { get; set; }

        public string Password { get; set; }

    }
}
