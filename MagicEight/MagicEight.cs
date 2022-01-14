using System;
using System.Collections.Generic;
using System.Text;
using Reddit;
using Reddit.Controllers.EventArgs;
using Reddit.Inputs.LinksAndComments;
using Reddit.Things;

namespace MagicEight
{
    class MagicEight
    {
        RedditClient reddit;

        public MagicEight(string id, string secret, string token)
        {
            try
            {
                reddit = new RedditClient(appId: id, appSecret: secret, refreshToken: token);
                Console.WriteLine($"Hello I am {reddit.Account.Me.Name} and I  was created on {reddit.Account.Me.Created}.");
                Console.WriteLine($"Got Messages: {reddit.Account.Me.HasMail}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: \n{e.ToString()}");
            }




        }

        public void Run()
        {
            Boolean Stop = false;

            reddit.Account.Messages.MonitorUnread(15000);
            reddit.Account.Messages.UnreadUpdated += C_UnreadMessagesUpdated;

            while (!Stop) { }

            reddit.Account.Messages.UnreadUpdated -= C_UnreadMessagesUpdated;
            reddit.Account.Messages.MonitorUnread();
        }

        private void C_UnreadMessagesUpdated(object sender, MessagesUpdateEventArgs e)
        {
            if (e.NewMessages.Count > 0)
            {
                foreach (Message message in e.NewMessages)
                {
                    if( message.WasComment)
                    {
                        Console.WriteLine($"Responding to messageID{message.Id}");
                        reddit.Comment(message.Name).Reply(GenerateResponse());
                        message.
                    }
                }
            }
        }

        private string GenerateResponse()
        {
            Random rnd = new Random();
            int x = rnd.Next(0, 19);
            return $"{responses[x]}" +
                $"I am a silly bot and will not respond to private messages.\nIf I am missbehaving, please notify u\\omen-f1";

            
        }

        private Dictionary<int, string> responses = new Dictionary<int, string>()
        {
            {0, "It is certain."},
            {1, "It is decidedly so."},
            {2, "Without a doubt."},
            {3, "Yes definitely."},
            {4, "You may rely on it."},
            {5, "As I see it, yes."},
            {6, "Most likely."},
            {7, "Outlook good."},
            {8, "Yes."},
            {9, "Signs point to yes."},
            {10, "Reply hazy, try again."},
            {11, "Ask again later."},
            {12, "Better not tell you now."},
            {13, "Cannot predict now."},
            {14, "Concentrate and ask again."},
            {15, "Dont count on it."},
            {16, "My reply is no."},
            {17, "My sources say no."},
            {18, "Outlook not so good."},
            {19, "Very doubtful."}

        };

    }
}
