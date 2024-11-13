using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainHoppers.Core.Domain;
using TrainHoppers.Core.Dto;

namespace TrainHoppers.Core.ServiceInterface
{
    public interface IFileServices
    {
        void UploadFilesToDatabase(AbilityDto dto, Ability domain);
        Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto);
    }
}
