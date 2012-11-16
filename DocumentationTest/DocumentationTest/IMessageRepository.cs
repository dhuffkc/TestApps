namespace DocumentationTest
{
	using System.Collections.Generic;

	public interface IMessageRepository
	{
		Message LoadMessage(int userId, int messageId);

		IEnumerable<MessageLog> LoadMessageLogEntries(int userId, int messageId);
	}
}
