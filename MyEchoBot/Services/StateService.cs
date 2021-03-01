using System;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EchoBot.Models;

namespace EchoBot.Services
{
    public class StateService
    {
        #region  Variables
        public UserState UserState
        {
            get;
        }
        public ConversationState ConversationState
        {
            get;
        }
        #endregion

        public static string UserProfileId { get; } = $"{nameof(StateService)}.UserProfile";
        public static string ConversationDataId { get; } = $"{nameof(StateService)}.ConversationData";

        public IStatePropertyAccessor<UserProfile> UserProfileAccessor { get; set; }
        public IStatePropertyAccessor<ConversationData> ConversationDataAccessor { get; set; }

        public StateService(UserState userState, ConversationState conversationState)
        {
            UserState = userState ?? throw new ArgumentNullException(nameof(userState));
            IntializeAccessors();
        }
        public void IntializeAccessors()
        {
            UserProfileAccessor = UserState.CreateProperty<UserProfile>(UserProfileId);
            ConversationDataAccessor = ConversationState.CreateProperty<ConversationData>(ConversationDataId);
        }
    }
}