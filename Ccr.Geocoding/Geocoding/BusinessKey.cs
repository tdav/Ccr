﻿using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.Geocoding
{
	/// <remarks>
	/// https://developers.google.com/maps/documentation/business/webservices/auth#business-specific_parameters
	/// </remarks>
	public class BusinessKey
	{
		/// <summary>
		/// More details about channel
		/// https://developers.google.com/maps/documentation/directions/get-api-key
		/// https://developers.google.com/maps/premium/reports/usage-reports#channels
		/// </summary>
		private string _channel;


		public string ClientId { get; set; }

		public string SigningKey { get; set; }

		public string Channel
		{
			get => _channel;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					return;
				
				var formattedChannel = value.Trim().ToLower();
				if (Regex.IsMatch(formattedChannel, @"^[a-z_0-9.-]+$"))
					_channel = formattedChannel;
				else
					throw new ArgumentException(
						$"\"{_channel}\" is not a valid ASCII alphanumeric string. Can include a " +
						$"period, underscore, and hyphen character.", 
						nameof(_channel));
			}
		}

		public bool HasChannel
		{
			get => !_channel.IsNullOrEmptyEx();
		}

		public BusinessKey(
			string clientId, 
			string signingKey, 
			string channel = null)
		{
			ClientId = checkParam(clientId, "clientId");
			SigningKey = checkParam(signingKey, "signingKey");
			Channel = channel;
		}

		private string checkParam(
			string value, 
			[NotNull, UsedImplicitly] string name)
		{
			value.IsNotNullOrEmptyEx(nameof(name));
			return value.Trim();
		}

		public string GenerateSignature(
			string url)
		{
			var encoding = new ASCIIEncoding();
			var uri = new Uri(url);
			
			var usablePrivateKey = SigningKey
				.Replace("-", "+")
				.Replace("_", "/");

			var privateKeyBytes = Convert
				.FromBase64String(usablePrivateKey);

			var encodedPathAndQueryBytes = encoding
				.GetBytes(uri.LocalPath + uri.Query);
			
			var algorithm = new HMACSHA1(privateKeyBytes);
			var hash = algorithm.ComputeHash(encodedPathAndQueryBytes);

			var signature = Convert.ToBase64String(hash)
				.Replace("+", "-")
				.Replace("/", "_");

			return $"{uri.Scheme}://{uri.Host}{uri.LocalPath}{uri.Query}&signature={signature}";
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as BusinessKey);
		}

		public bool Equals(BusinessKey other)
		{
			if (other == null)
				return false;

			return ClientId.Equals(other.ClientId) 
				&& SigningKey.Equals(other.SigningKey);
		}

		public override int GetHashCode()
		{
			return ClientId.GetHashCode() ^ SigningKey.GetHashCode();
		}

		public override string ToString()
		{
			return $"ClientId: {ClientId}, SigningKey: {SigningKey}";
		}
	}
}