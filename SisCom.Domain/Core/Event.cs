using MediatR;
using System;

namespace SisCom.Domain.Core
{
    public class Event : INotification
    {
        public DateTime DataOcorrencia => DateTime.Now;
    }
}
