using System;

namespace Gamebase.Loader
{
    public interface IErrorReceiver
    {
        IObservable<ErrorMessage> OnErrorAsObservable();
    }
}