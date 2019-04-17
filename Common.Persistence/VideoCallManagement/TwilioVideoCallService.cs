using Common.Persistence.VideoCallManagement.VideoCallDto;
using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Converters;
using Twilio.Jwt.AccessToken;
using Twilio.Rest.Api.V2010.Account.Conference;
using Twilio.Rest.Video.V1;

namespace Common.Persistence.VideoCallManagement
{
    public class TwilioVideoCallService : IVideoCallService
    {
        private readonly string _apiKey;
        private readonly string _apiAccountSid;
        private readonly string _apiKeySecret;
        private readonly string _accountSid;
        private readonly DateTime _expiryTime;

        public TwilioVideoCallService(TwilioConfiguration configuration)
        {
            _apiKey = configuration.ApiKey;
            _apiAccountSid = configuration.ApiAccountSid;
            _apiKeySecret = configuration.ApiKeySecret;
            _accountSid = configuration.AccountSid;
            _expiryTime = configuration.ExpiryTime;
        }

        public Tuple<Token, string> CreateToken()
        {
            // Create a video grant for the token
            var grant = new VideoGrant();

            var grants = new HashSet<IGrant> { grant };
            var identity = Guid.NewGuid();

            // Create an Access Token generator
            var token = new Token(_apiAccountSid, _apiKey, _apiKeySecret, identity.ToString(), 
                _expiryTime, DateTime.Now, grants);

            // Serialize the token as a JWT
            return new Tuple<Token, string>(token, identity.ToString());
        }

        public string CreateRoom(string token, string roomUniqueName)
        {
            TwilioClient.Init(_apiAccountSid, _accountSid);

            var room = RoomResource.Create(new CreateRoomOptions()
            {
                UniqueName = roomUniqueName,
                EnableTurn = true,
                Type = RoomResource.RoomTypeEnum.Group,
                RecordParticipantsOnConnect = true
            });

            return room.Sid;
        }

        public string CompleteRoom(string roomSid)
        {
            TwilioClient.Init(_apiAccountSid, _apiKeySecret);

            var room = RoomResource.Update(roomSid, RoomResource.RoomStatusEnum.Completed);

            return room.Sid;
        }

        public string AddParticipant(string roomSid, string participantSid)
        {
            //var participantResource = ParticipantResource.Update(roomSid, participantSid, ParticipantResource.StatusEnum.Connected.ToString());

            //return participantResource.AccountSid;
            return null;
        }

        public string RemoveParticipant(string roomSid, string participantSid)
        {
            //var participantResource = ParticipantResource.Update(roomSid, participantSid, ParticipantResource.StatusEnum.Complete.ToString());

            //return participantResource.AccountSid;
            return null;
        }

        public CompositionResource CreateComposition(string roomSid, List<string> recordingSids)
        {
            var compositionOptions = new CreateCompositionOptions
            {
                RoomSid = roomSid,
                //StatusCallback = new Uri("https://dda50c80.ngrok.io/Call/CompositionCallBack"),
                Format = "mp4",
                VideoLayout = new
                {
                    grid = new { video_sources = new List<string> { "*" } }
                },
                AudioSources = new List<string> { "*" }
            };

            TwilioClient.Init(_apiAccountSid, _accountSid);

            var composition = CompositionResource.Create(compositionOptions);

            return composition;
        }

        public List<CompositionDto> GetAllCompositions()
        {
            TwilioClient.Init(_apiAccountSid, _accountSid);

            var compositions = CompositionResource.Read(new ReadCompositionOptions
            {
                Status = CompositionResource.StatusEnum.Completed
            });

            List<CompositionDto> compositionLst = new List<CompositionDto>();

            foreach (var comp in compositions)
            {
                compositionLst.Add(new CompositionDto
                {
                    CompositionSid = comp.Sid,
                    Links = comp.Links,
                    Url = comp.Url
                });
            }

            return compositionLst;
        }

        public bool DeleteComposition(string compositionSid)
        {
            TwilioClient.Init(_apiAccountSid, _accountSid);

            var isDeleted = CompositionResource.Delete(compositionSid);
            return isDeleted;
        }        

        public List<RecordingDto> GetAllRecordingsOfRoom(string roomSid)
        {
            return null;
            //TwilioClient.Init(_apiAccountSid, _accountSid);

            //var recordings = Twilio.Rest.Api.V2010.Account.RecordingResource.Read(
            //    groupingSid: Promoter.ListOfOne(roomSid)
            //);

            //List<RecordingDto> recordingLst = new List<RecordingDto>();

            //foreach (var record in recordings)
            //{
            //    recordingLst.Add(new RecordingDto
            //    {
            //        RecordingSid = record.Sid,
            //        Url = record.Uri
            //    });
            //}

            //return recordingLst;
        }

        public List<RoomDto> GetCompletedRooms()
        {
            TwilioClient.Init(_apiAccountSid, _accountSid);

            var rooms = RoomResource.Read(status: RoomResource.RoomStatusEnum.Completed);
            List<RoomDto> roomLst = new List<RoomDto>();

            foreach (var record in rooms)
            {
                roomLst.Add(new RoomDto
                {
                    RoomSid = record.Sid,
                    DateCreated = record.DateCreated,
                    UniqueName = record.UniqueName
                });
            }

            return roomLst;
        }
    }
}
