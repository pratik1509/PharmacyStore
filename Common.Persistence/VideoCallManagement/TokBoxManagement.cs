using Common.Persistence.VideoCallManagement.TokBoxDto;
using OpenTokCore;
using OpenTokCore.Exception;
using System;
using System.Threading.Tasks;

namespace Common.Persistence.VideoCallManagement
{
    public class TokBoxManagement : ITokBoxManagement
    {
        private readonly OpenTok _openTok;

        public TokBoxManagement(TokBoxConfiguration configuraiton)
        {
            _openTok = new OpenTok(configuraiton.ApiKey, configuraiton.ApiSecret);
        }

        public async Task<string> CreateSession(CreateSessionDto createSessionDto)
        {  
            var session = await _openTok.CreateSession(createSessionDto.Location,
                createSessionDto.MediaMode, createSessionDto.ArchiveMode);
            return session.Id;
        }

        public string GenerateToken(GenerateTokenDto tokenDto)
        {
            double inOneWeek = (DateTime.UtcNow.Add(TimeSpan.FromDays(tokenDto.ExpireTokenInDays)).Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            return _openTok.GenerateToken(tokenDto.SessionId, tokenDto.Role, inOneWeek, tokenDto.Data);            
        }

        public async Task<Guid> StartRecording(StartRecordingDto startRecordingDto)
        {
            try {
                var recording = await _openTok.StartArchive(startRecordingDto.SessionId, startRecordingDto.UniqueRecordingName);
                return recording.Id;
            }
            // if recording is already running
            catch(OpenTokWebException ex) {
                return Guid.Empty;
            }
        }

        public async Task<Guid> StopRecording(string recordingId)
        {
            var recording = await _openTok.StopArchive(recordingId);
            return recording.Id;
        }

        public void DeleteRecording(string recordingId)
        {
            _openTok.DeleteArchive(recordingId);
        }

        public async Task<ArchiveList> GetListOfRecordings(GetListOfRecordingsDto getListOfRecordingsDto)
        {
            // find the start record number from page number and page size           
            int recordStartFrom = (getListOfRecordingsDto.PageNumber * getListOfRecordingsDto.PageSize) - getListOfRecordingsDto.PageSize;
            return await _openTok.ListArchives(recordStartFrom, getListOfRecordingsDto.PageSize);
        }
    }
}
