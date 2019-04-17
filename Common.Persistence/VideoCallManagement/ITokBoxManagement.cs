using Common.Persistence.VideoCallManagement.TokBoxDto;
using OpenTokCore;
using System;
using System.Threading.Tasks;

namespace Common.Persistence.VideoCallManagement
{
    public interface ITokBoxManagement
    {
        Task<string> CreateSession(CreateSessionDto createSessionDto);
        string GenerateToken(GenerateTokenDto tokenDto);
        Task<Guid> StartRecording(StartRecordingDto startRecordingDto);
        Task<Guid> StopRecording(string recordingId);
        void DeleteRecording(string recordingId);
        Task<ArchiveList> GetListOfRecordings(GetListOfRecordingsDto getListOfRecordingsDto);
    }
}
