using System;
using UniRx.Async;

namespace Gamebase.Loader.Data
{
    public interface IRequiredVersionRepository
    {
        UniTask<string> Get();

        IObservable<string> OnChangeAsObservable();
    }
}