using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainHoppers.Core.Dto;

namespace TrainHoppers.Core.ServiceInterface
{
    public interface IEmailsServices
    {
        void SendEmail(EmailDto dto);
        void SendEmailToken(EmailTokenDto dto,string token);
    }
}
