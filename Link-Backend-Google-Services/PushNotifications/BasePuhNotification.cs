﻿using FirebaseAdmin.Messaging;

namespace Link_Backend_Google_Services.PushNotifications
{
    public class BasePuhNotification
    {
        public async Task SendNotifications(string title, string body, string strPath, string strISSync, string image, List<TokenDevice> tokenDevices)
        {
            //string key = Settings.AESKey.aesKey;
            //string iv = Settings.AESIv.aesIV;

            foreach (var tokenDevice in tokenDevices)
            {
                //string descDeviceToken = AESEncDec.AESDecryption(tokenDevice.DeviceToken, key, iv);

                var message = new FirebaseAdmin.Messaging.Message()
                {
                    Notification = new FirebaseAdmin.Messaging.Notification
                    {
                        Title = title,
                        Body = body
                    },
                    //Token = descDeviceToken,
                    Token = tokenDevice.DeviceToken,
                    Data = new Dictionary<string, string>
                    {
                        { "Path", strPath },
                        { "IsSync", strISSync },
                        { "ImageUrl", image }
                    }
                };

                try
                {
                    await FirebaseMessaging.DefaultInstance.SendAsync(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}