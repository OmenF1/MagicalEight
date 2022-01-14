using System;
using System.Collections.Generic;
using System.Text;
using Reddit;

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
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: \n{e.ToString()}");
            }




        }

        //public void run()
        //{
        //    Boolean Stop = false;

        //    reddit.Account.Messages.MonitorUnread(15000);
        //    reddit.Account.Messages.UnreadUpdated += C_UnreadMessagesUpdated;

        //    while (!Stop) { }

        //    reddit.Account.Messages.UnreadUpdated -= C_UnreadMessagesUpdated;
        //    reddit.Account.Messages.MonitorUnread();
        //}


    }
}
