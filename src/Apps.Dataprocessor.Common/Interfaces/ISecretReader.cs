using System;
using System.Collections.Generic;
using System.Text;

namespace Apps.Dataprocessor.Common.Interfaces
{
    public interface ISecretReader
    {
        string GetSecret(string secretLocationUri, string secretName);
    }
}
