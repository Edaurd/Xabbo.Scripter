﻿using System;
using System.Linq;

using Xabbo.Messages;
using Xabbo.Interceptor;
using Xabbo.Core;
using System.Collections.Generic;

namespace Xabbo.Scripter.Scripting
{
    public partial class G
    {
        /// <summary>
        /// Mutes a user for the specified number of minutes.
        /// </summary>
        public void Mute(long userId, int minutes, long? roomId = null) => Interceptor.Send(Out.RoomMuteUser, userId, roomId ?? GetRoomOrThrow().Id, minutes);

        /// <summary>
        /// Mutes a user for the specified number of minutes.
        /// </summary>
        public void Mute(IRoomUser user, int minutes) => Mute(user.Id, minutes);

        /// <summary>
        /// Kicks the specified user from the room.
        /// </summary>
        public void Kick(long userId) => Interceptor.Send(Out.KickUser, (LegacyLong)userId);

        /// <summary>
        /// Kicks the specified user from the room.
        /// </summary>
        public void Kick(IRoomUser user) => Kick(user.Id);

        /// <summary>
        /// Bans a user from the current room for the specified duration.
        /// </summary>
        public void Ban(long userId, BanDuration duration) => Interceptor.Send(Out.RoomBanWithDuration, userId, Room.Id, duration.GetValue());

        /// <summary>
        /// Bans a user from the current room for the specified duration.
        /// </summary>
        public void Ban(IRoomUser user, BanDuration duration) => Ban(user.Id, duration);

        /// <summary>
        /// Unbans a user from the specified room.
        /// </summary>
        public void Unban(long userId, long? roomId = null) => Interceptor.Send(Out.RoomUnbanUser, userId, roomId ?? GetRoomOrThrow().Id);

        /// <summary>
        /// Unbans the specified user.
        /// </summary>
        public void Unban(IRoomUser user) => Unban(user.Id);

        /// <summary>
        /// Gives rights to the current room to the specified user.
        /// </summary>
        public void GiveRights(long userId) => Interceptor.Send(Out.AssignRights, userId);

        /// <inheritdoc cref="GiveRights(long)" />
        public void GiveRights(IRoomUser user) => GiveRights(user.Id);

        /// <summary>
        /// Removes rights to the current room from the specified users.
        /// </summary>
        public void RemoveRights(IEnumerable<long> userIds) => Interceptor.Send(Out.RemoveRights, userIds);

        /// <inheritdoc cref="RemoveRights(IEnumerable{long})" />
        public void RemoveRights(IEnumerable<IRoomUser> users) => RemoveRights(users.Select(x => x.Id));
    }
}
