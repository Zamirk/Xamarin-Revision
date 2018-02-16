using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xamarin_Experiments.FileIO
{
    interface IFileHelper
    {
        Task<bool> ExistsAsync(string filename);
        Task WriteTextAsync(string filename, string text);
        Task<string> ReadTextAsync(string filename);
        Task<IEnumerable<string>> GetFilesAsync();
        Task DeleteAsync(string filename);
        
        //TODO 16/02/18 Create an inplementation for Android/UWP/IOS
    }
}
