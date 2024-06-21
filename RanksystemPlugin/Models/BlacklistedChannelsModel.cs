﻿using Dapper.Contrib.Extensions;

namespace RankSystem.Models;

[Table("RankSystemBlacklistedChannelsIndex")]
public record BlacklistedChannelsModel
{
    public ulong GuildId { get; set; }
    public ulong ChannelId { get; set; }
}