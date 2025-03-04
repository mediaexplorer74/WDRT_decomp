﻿using System;
using System.Runtime.Serialization;

namespace System.Security.Authentication
{
	/// <summary>The exception that is thrown when authentication fails for an authentication stream.</summary>
	// Token: 0x0200043A RID: 1082
	[Serializable]
	public class AuthenticationException : SystemException
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Authentication.AuthenticationException" /> class with no message.</summary>
		// Token: 0x0600286D RID: 10349 RVA: 0x000B9C6E File Offset: 0x000B7E6E
		public AuthenticationException()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Authentication.AuthenticationException" /> class from the specified instances of the <see cref="T:System.Runtime.Serialization.SerializationInfo" /> and <see cref="T:System.Runtime.Serialization.StreamingContext" /> classes.</summary>
		/// <param name="serializationInfo">A <see cref="T:System.Runtime.Serialization.SerializationInfo" /> instance that contains the information required to deserialize the new <see cref="T:System.Security.Authentication.AuthenticationException" /> instance.</param>
		/// <param name="streamingContext">A <see cref="T:System.Runtime.Serialization.StreamingContext" /> instance.</param>
		// Token: 0x0600286E RID: 10350 RVA: 0x000B9C76 File Offset: 0x000B7E76
		protected AuthenticationException(SerializationInfo serializationInfo, StreamingContext streamingContext)
			: base(serializationInfo, streamingContext)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Authentication.AuthenticationException" /> class with the specified message.</summary>
		/// <param name="message">A <see cref="T:System.String" /> that describes the authentication failure.</param>
		// Token: 0x0600286F RID: 10351 RVA: 0x000B9C80 File Offset: 0x000B7E80
		public AuthenticationException(string message)
			: base(message)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Authentication.AuthenticationException" /> class with the specified message and inner exception.</summary>
		/// <param name="message">A <see cref="T:System.String" /> that describes the authentication failure.</param>
		/// <param name="innerException">The <see cref="T:System.Exception" /> that is the cause of the current exception.</param>
		// Token: 0x06002870 RID: 10352 RVA: 0x000B9C89 File Offset: 0x000B7E89
		public AuthenticationException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
