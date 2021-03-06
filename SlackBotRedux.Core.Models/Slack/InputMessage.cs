﻿using System.Collections.Generic;

namespace SlackBotRedux.Core.Models.Slack
{
    /// <summary>
    /// Contains information about Slack messages.
    /// More information can be found at https://api.slack.com/events/message.
    /// </summary>
    public class InputMessage
    {
        public string Type { get; set; }
        public MessageSubType SubType { get; set; }

        /// <summary>
        /// The id of the user who sent this message (if a user event sent this message).
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// The id of the channel this message was posted in.
        /// </summary>
        public string Channel { get; set; }

        public string Text { get; set; }

        /// <summary>
        /// The unique (per-channel) timestamp.
        /// </summary>
        public string Ts { get; set; }

        public class EditedData
        {
            /// <summary>
            /// The id of the user who has edited the message.
            /// </summary>
            public string User { get; set; }

            /// <summary>
            /// The unique (per-channel) timestamp of the edit.
            /// </summary>
            public string Ts { get; set; }
        }
        public EditedData Edited { get; set; }

        public List<Attachment> Attachments { get; set; }

        // TODO: find way of supporting all the metadata associated with the derived message types
    }

    public class InputMessageSlim
    {
        public string ChannelId { get; set; }
        public string Text { get; set; }
        public string Timestamp { get; set; }
        public string UserId { get; set; }
    }

    public class MessageList : List<InputMessageSlim>
    {
        public void Add(string text)
        {
            Add(new InputMessageSlim() { Text = text });
        }
    }

    public enum MessageSubType
    {
        PlainMessage,
        BotMessage,
        MeMessage,
        MessageChanged,
        MessageDeleted,
        ChannelJoin,
        ChannelLeave,
        ChannelTopic,
        ChannelPurpose,
        ChannelName,
        ChannelArchive,
        ChannelUnarchive,
        GroupJoin,
        GroupLeave,
        GroupTopic,
        GroupPurpose,
        GroupName,
        GroupArchive,
        GroupUnarchive,
        FileShare,
        FileComment,
        FileMention
    }
}
