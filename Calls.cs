﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectT;
using Terraria.ModLoader;

namespace LuckyRunes
{
	public static class Calls
	{
		static public Mod ProjectTMod => LuckyRunes.ProjectTMod;


		/// <summary>Send a message to chat.</summary>
        /// <param name="message">Message to send.</param>
		public static void SendMessage(string message)
		{
			if (ProjectTMod != null)
			{
				//requires the operator "SendMessage" and a message
				ProjectTMod.Call("SendMessage", message);
			}
		}

		//Send a whisper to a specific person
		public static void SendWhisper(string name, string message)
		{
			if (ProjectTMod != null)
			{
				//BEWARE: please make sure you know the limitations twitch set on bot-whispers. They're extremely low and sending a whisper WILL create problems in the long run
				//due to this, this function MAY be removed in future versions of Project-T

				//requires the operator "SendWhisper", a receiver (username as string) and a message
				ProjectTMod.Call("SendWhisper", name, message);
			}
		}

		//The "Viewers" I require for adding and removing coins don't have to be 100% accurate. Only the Username and UserID are required. the rest can just be null.
		static public bool RemoveCoin(Viewer viewer, double CoinsToRemove)
		{
			if (ProjectTMod != null)
			{
				//you cannot send a double. I convert it back to a double on my end. I have no idea why it is like that either.
				string req = Convert.ToString(CoinsToRemove);

				try
				{
					//requires the operator "RemoveCoins", a receiver the amount
					bool answer = ProjectTMod.Call("RemoveCoins", viewer, req) is bool result && result;
					return answer;
				}
				catch
				{
					return false;
				}
				//Note: checking if the viewer exists, and if he has enough coins is done on my part. you don't have to implement that
				//If the user doesn't exist or doesn't have enough coins I return a false
				//If the user exists, has enough coins and the coins were removed successfully, I return true
			}
			return false;
		}

		static public void AddCoins(Viewer viewer, double CoinsToAdd)
		{
			if (ProjectTMod != null)
			{
				//you cannot send a double. I convert it back to a double on my end.
				string req = Convert.ToString(CoinsToAdd);

                //Requires the operator "AddCoins", a receiver and amount. I check on my side if the user exists. you don't have to. But you won't get a return here.
                ProjectTMod.Call("AddCoins", viewer, req);
			}
		}
	}
}