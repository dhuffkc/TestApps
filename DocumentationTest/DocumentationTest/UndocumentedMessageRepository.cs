// -----------------------------------------------------------------------
// <copyright file="UndocumentedMessageRepository.cs" company="ScriptPro LLC">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DocumentationTest
{
	using System.Collections.Generic;

public class UndocumentedMessageRepository : IMessageRepository
{
	public Message LoadMessage(int userId, int messageId)
	{
		return null;
	}

	public IEnumerable<MessageLog> LoadMessageLogEntries(int userId, int messageId)
	{
		return null;
	}
}
}
