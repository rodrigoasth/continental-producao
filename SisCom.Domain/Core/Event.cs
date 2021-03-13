using MediatR;
using System;

namespace Continental.Producao.Domain.Core
{
    public class Event : INotification
    {
        public DateTime DataOcorrencia => DateTime.Now;
    }
}
