using Ansari_Website.Application.Common.Exceptions;
using Ansari_Website.Application.TodoItems.Commands.CreateTodoItem;
using Ansari_Website.Application.TodoItems.Commands.DeleteTodoItem;
using Ansari_Website.Application.TodoLists.Commands.CreateTodoList;
using Ansari_Website.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace Ansari_Website.Application.IntegrationTests.TodoItems.Commands;

using static Testing;

public class DeleteTodoItemTests : TestBase
{
    [Test]
    public async Task ShouldRequireValidTodoItemId()
    {
        var command = new DeleteTodoItemCommand { Id = 99 };

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoItem()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        var itemId = await SendAsync(new CreateTodoItemCommand
        {
            ListId = listId,
            Title = "New Item"
        });

        await SendAsync(new DeleteTodoItemCommand
        {
            Id = itemId
        });

        var item = await FindAsync<TodoItem>(itemId);

        item.Should().BeNull();
    }
}
