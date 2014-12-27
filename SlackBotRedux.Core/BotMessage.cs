﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SlackBotRedux.Core.Models;

namespace SlackBotRedux.Core
{
    public abstract class BotMessage
    {
        public BotMessageType Type { get; set; }
        public bool IsFinishedBeingProcessed { get; set; }

        public BotMessage(BotMessageType type)
        {
            Type = type;
        }
    }

    public class UpdateTeamBotMessage : BotMessage
    {
        public TeamState TeamState { get; set; }

        public UpdateTeamBotMessage(TeamState teamState) : base(BotMessageType.UpdateTeam)
        {
            TeamState = teamState;
        }
    }
    public class UpdateUserBotMessage : BotMessage
    {
        public User User { get; set; }

        public UpdateUserBotMessage(User user) : base(BotMessageType.UpdateUser)
        {
            User = user;
        }
    }

    public class TextInputBotMessage : BotMessage
    {
        public InputMessage Message { get; set; }
        public Match Match { get; set; }

        public TextInputBotMessage(InputMessage msg) : base(BotMessageType.TextInput)
        {
            Message = msg;
        }
    }

    public class FallbackMessage : BotMessage
    {
        public BotMessage OriginalMessage { get; private set; }

        public FallbackMessage(BotMessage originalMessage) : base(BotMessageType.Fallback)
        {
            OriginalMessage = originalMessage;
        }
    }

    public enum BotMessageType
    {
        UpdateTeam,
        UpdateUser,
        TextInput,
        Fallback
    }
}