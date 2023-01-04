﻿namespace BillSplit.Contracts.Authorization;

public sealed class JwtSettings
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Key { get; set; }
};