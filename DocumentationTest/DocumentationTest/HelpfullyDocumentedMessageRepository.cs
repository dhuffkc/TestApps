// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HelpfullyDocumentedMessageRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The helpfully documented message repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace DocumentationTest
{
/// <summary>
/// The helpfully documented message repository.
/// </summary>
public class HelpfullyDocumentedMessageRepository : IMessageRepository
{
	#region IMessageRepository Members

	/// <summary>
	/// Load a message.
	/// </summary>
	/// <param name="userId">
	/// The user id.
	/// </param>
	/// <param name="messageId">
	/// The message id.
	/// </param>
	/// <returns>
	/// The message.
	/// </returns>
	public Message LoadMessage(int userId, int messageId)
	{
		return null;
	}

	/// <summary>
	/// Load message log entries.
	/// </summary>
	/// <param name="userId">
	/// The user id.
	/// </param>
	/// <param name="messageId">
	/// The message id.
	/// </param>
	/// <returns>
	/// A set of message log entries
	/// </returns>
	/// <exception cref="NotImplementedException">
	/// </exception>
	public IEnumerable<MessageLog> LoadMessageLogEntries(int userId, int messageId)
	{
		return null;
	}

	#endregion
}
}