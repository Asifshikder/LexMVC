//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Mail;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Threading.Tasks.Dataflow;

//namespace LexMVC.Helpers
//{
//    public class EmailSenderHostedService : IEmailSender, IHostedService, IDisposable
//    {
//        //The BufferBlock<T> is a thread-safe producer/consumer queue
//        private readonly BufferBlock<MailMessage> mailMessages;
//        private readonly ILogger logger;
//        private readonly SmtpClient smtpClient;
//        private Task sendTask;
//        private CancellationTokenSource cancellationTokenSource;
//        public EmailSenderHostedService(IConfiguration configuration, ILogger<EmailSenderHostedService> logger)
//        {
//            this.logger = logger;
//            this.mailMessages = new BufferBlock<MailMessage>();
//            this.smtpClient = CreateSmtpClient(configuration);
//        }

//        private SmtpClient CreateSmtpClient(IConfiguration configuration)
//        {
//            return new SmtpClient
//            {
//                Host = configuration["Smtp:Host"],
//                Port = configuration.GetValue<int>("Smtp:Port"),
//                EnableSsl = configuration.GetValue<bool>("Smtp:Ssl"),
//                UseDefaultCredentials = false,
//                DeliveryMethod = SmtpDeliveryMethod.Network,
//                Credentials = new NetworkCredential(
//                                    userName: configuration["Smtp:Username"],
//                                    password: configuration["Smtp:Password"]
//                )
//            };
//        }

//        public Task StartAsync(CancellationToken cancellationToken)
//        {
//            logger.LogInformation("Starting background e-mail delivery");
//            cancellationTokenSource = new CancellationTokenSource();
//            sendTask = Send(cancellationTokenSource.Token);
//            return Task.CompletedTask;
//        }
//        public async Task StopAsync(CancellationToken cancellationToken)
//        {
//            //Let's cancel the e-mail delivery
//            CancelSendTask();
//            //Next, we wait for sendTask to end, but no longer than what the web host allows
//            await Task.WhenAny(sendTask, Task.Delay(Timeout.Infinite, cancellationToken));
//        }

//        private void CancelSendTask()
//        {
//            try
//            {
//                if (cancellationTokenSource != null)
//                {
//                    logger.LogInformation("Stopping e-mail background delivery");
//                    cancellationTokenSource.Cancel();
//                    cancellationTokenSource = null;
//                }
//            }
//            catch
//            {

//            }
//        }

//        public void Post(string subject, string body, string recipients, string sender)
//        {
//            MailMessage message = new MailMessage(from: sender,to: recipients);
//            //message.From.Address(sender);
//            message.Subject = subject;
//            message.IsBodyHtml = true;
//            message.Body = body;
//            //message.To.Add(recipients);

//            //if (attachmentFilename != null)
//            //    message.Attachments.Add(new Attachment(attachmentFilename));


//            //    var mailMessage = new MailMessage(
//            //       from: sender,
//            //       to: recipients

//            //    )
//            //    {
//            //        Subject = subject,
//            //        Body = body,
//            //        IsBodyHtml = true
//            //};

//            //#warning Implement durable persistence or messages will be lost when the application is terminated
//            bool posted = mailMessages.Post(message);
//            if (!posted)
//            {
//                //This should never happen since we don't stop the underlying BufferBlock
//                throw new InvalidOperationException("This service is no longer accepting e-mails");
//            }
//        }
        
//        public void PostWithFile(string subject, string body, string recipients, string sender,string attachmentFilename)
//        {
//            MailMessage message = new MailMessage(from: sender,to: recipients);
//            //message.From.Address(sender);
//            message.Subject = subject;
//            message.IsBodyHtml = true;
//            message.Body = body;
//            //message.To.Add(recipients);

//            if (attachmentFilename != null)
//                message.Attachments.Add(new Attachment(attachmentFilename));


//            //    var mailMessage = new MailMessage(
//            //       from: sender,
//            //       to: recipients

//            //    )
//            //    {
//            //        Subject = subject,
//            //        Body = body,
//            //        IsBodyHtml = true
//            //};

//            //#warning Implement durable persistence or messages will be lost when the application is terminated
//            bool posted = mailMessages.Post(message);
//            if (!posted)
//            {
//                //This should never happen since we don't stop the underlying BufferBlock
//                throw new InvalidOperationException("This service is no longer accepting e-mails");
//            }
//        }

//        public async Task Send(CancellationToken token)
//        {
//            logger.LogInformation("E-mail background delivery started");

//            while (!token.IsCancellationRequested)
//            {
//                MailMessage message = null;
//                try
//                {
//                    //Let's wait for a message to appear in the queue
//                    //If the token gets canceled, then we'll stop waiting
//                    //since an OperationCanceledException will be thrown
//                    message = await mailMessages.ReceiveAsync(token);

//                    //as soon as a message is available, we'll send it
//                    await smtpClient.SendMailAsync(message);
//                    logger.LogInformation($"E-mail sent to {message.To}");
//                }
//                catch (OperationCanceledException)
//                {
//                    //We need to terminate the delivery, so we'll just break the while loop
//                    break;
//                }
//                catch
//                {
//                    //#warning Implement a retry mechanism or else this message will be lost
//                    logger.LogWarning($"Couldn't send an e-mail to {message.To}");
//                }
//            }

//            logger.LogInformation("E-mail background delivery stopped");
//        }

//        public void Dispose()
//        {
//            CancelSendTask();
//        }
//    }
//}
