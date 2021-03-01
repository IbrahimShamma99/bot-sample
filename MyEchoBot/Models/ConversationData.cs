using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace EchoBot.Models
{

    public class ConversationData
    {
        public bool PromptedUserForName { get; set; } = false;
    }


}