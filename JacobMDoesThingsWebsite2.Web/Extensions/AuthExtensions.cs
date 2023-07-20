namespace JacobMDoesThingsWebsite2.Web.Extensions;

/// <summary>
/// Extension methods dealing with a user's identity and authentication state.
/// </summary>
public static class AuthExtensions
{
    /// <summary>
    /// Returns user's initials from the <see cref="AuthenticationState"/> ranging from 1 to n (default 2 max).
    /// </summary>
    /// <param name="authState">The <see cref="AuthenticationState"/>.</param>
    /// <param name="length">The desired length of initials such as: 1 = j, 2 = jm, 3 = jmd ... default is 2.</param>
    /// <param name="delimiters">
    /// The array of delimiters for suggesting next part of name such as space or ,. Max length is 5.
    /// </param>
    /// <returns>a<see cref="string"/>value of the first two initials specified by the dilimeters.</returns>
    public static string UserInitials(this AuthenticationState authState, int length = 2, char[]? delimiters = null)
    {
        if (delimiters?.Length > 5)
        {
            throw new ArgumentException($"{nameof(delimiters)} length must be 5 or less.");
        }

        var identity = authState.User.Identity;
        var returnVal = string.Empty;

        if (identity is not null && identity.IsAuthenticated)
        {
            returnVal = GetInitialsFromName(identity.Name, length, delimiters);
        }

        return returnVal;
    }

    private static string GetInitialsFromName(string? name, int length, char[]? delimiters = null)
    {
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }

        delimiters ??= new char[] { ' ' };

        ReadOnlySpan<char> nameSpan = name;
        Span<char> returnVal = new char[2];
        returnVal[0] = name.ElementAt(0);

        int lengthCount = 0;

        for (int i = 0; i < nameSpan.Length; i++)
        {
            if (length - 1 == lengthCount)
            {
                break;
            }
            foreach (char t in delimiters)
            {
                if (t == nameSpan[i] && !(delimiters.Contains(nameSpan[i + 1])))
                {
                    lengthCount++;
                    returnVal[lengthCount] = nameSpan[nameSpan.IndexOf(nameSpan[i]) + 1];
                    break;
                }
            }
        }
        return returnVal.ToString().Trim();
    }
}
