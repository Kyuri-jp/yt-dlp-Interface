using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yt_dlp_Interface.Brancher.Interfaces;

namespace yt_dlp_Interface.Libs.Client
{
    internal class Argument<TFlagEmum>(IOptionSelector optionSelector, Dictionary<TFlagEmum, string> argumentTable) : IDisposable where TFlagEmum : Enum
    {
        private Dictionary<TFlagEmum, string> arguments = [];
        private bool disposedValue;

        internal void Select()
        {
            optionSelector.Ask();
        }

        internal Dictionary<TFlagEmum, string> Get() => arguments;

        //<summary>
        //Add a new argument to the argument list
        //</summary>
        /// <param name="arguments">Key is Flag.Value is value of the flag.</param>
        /// <returns></returns>
        internal void Add(KeyValuePair<TFlagEmum, string> arguments) => this.arguments.Add(arguments.Key, arguments.Value);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: マネージド状態を破棄します (マネージド オブジェクト)
                }

                // TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
                // TODO: 大きなフィールドを null に設定します
                disposedValue = true;
            }
        }

        // // TODO: 'Dispose(bool disposing)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
        // ~Argument()
        // {
        //     // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}