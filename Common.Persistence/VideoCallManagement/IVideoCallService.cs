using Common.Persistence.VideoCallManagement.VideoCallDto;
using System;
using System.Collections.Generic;
using Twilio.Jwt.AccessToken;
using Twilio.Rest.Video.V1;

namespace Common.Persistence.VideoCallManagement
{
    public interface IVideoCallService
    {
        // twilio call service
        string AddParticipant(string roomSid, string participantSid);
        string CompleteRoom(string roomSid);
        string CreateRoom(string token, string roomUniqueName);
        Tuple<Token, string> CreateToken();
        string RemoveParticipant(string roomSid, string participantSid);
        CompositionResource CreateComposition(string roomSid, List<string> recordingSids);
        List<CompositionDto> GetAllCompositions();
        List<RoomDto> GetCompletedRooms();
        List<RecordingDto> GetAllRecordingsOfRoom(string roomSid);
        bool DeleteComposition(string compositionSid);
    }
}
