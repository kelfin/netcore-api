using System;

namespace Codebase.API;

public static class AppSetting
{
    public static string SigningKey { set; get; }
    public static int ExpirationMinutes { set; get; }
}
