using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System;
using EchoBot.Services;
using EchoBot.Models;

namespace EchoBot.Bots
{

    public class GreetBot : ActivityHandler
    {
        private readonly StateService _stateService;
        public GreetBot(StateService stateService)
        {
            _stateService = _stateService ?? throw new System.ArgumentNullException(nameof(stateService));
        }
        private async Task GetName(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            UserProfile userProfile = await _stateService.UserProfileAccessor.GetAsync(turnContext, () => new UserProfile());
            if (!string.IsNullOrEmpty(userProfile.Name))
            {
                await turnContext.SendActivityAsync(MessageFactory.Text("HI {0}. How Can I help you today?", userProfile.Name), cancellationToken);
            }
            else
            {
                if (conversationAccount.PromptedUserForName) {
                    userProfile.Name = turnContext.Activity.Text?.Trim();
                    await turnContext.SendActivityAsync(MessageFactory.Text("Thanks {0}. How Can I help you today?", userProfile.Name), cancellationToken);
                    conversationAccount.PromptedUserForName = false;
                }
                else {
                    await turnContext.SendActivityAsync(MessageFactory.Text("What is your name?"), cancellationToken);
                    conversationAccount.PromptedUserForName = true;

                }
            }
        }
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
        }
        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            var welcomeText = "Hello and welcome!";
            foreach (var member in membersAdded)
            {
                Console.WriteLine("\n\n\n member id", member.Id);
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                }
            }
        }
    }
}