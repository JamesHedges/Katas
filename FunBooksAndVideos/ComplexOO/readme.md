Complex Object Oriented FunBooksAndVideo Solution
==================================================

Motivation
----------

When initially solving the FunBooksAndVideo problem, the decision was made to keep it simple and not "over engineer" the solution. This was done with the assumption that all items would be processed based on their ItemLineType. When presented with a business rule that invalidated this assumption, it became painfully obvious that the simple solution was not viable.

You may find the simple solution at [SimpleOOSolution](https://github.com/JamesHedges/Katas/tree/master/FunBooksAndVideos/SimpleOO)

To further generalize the solution, it was decided to take a Domain Driven Design approach. Note that this was the original solution that was deemed "over engineered." With this approach, using domain event will be able to handle the various item processing business rule specifications.

Notes
-----

### Infrastrucure

#### Domain Events

Using the [MediatR](https://github.com/jbogard/MediatR/wiki) Nuget package to facilitate domain events. 

#### Testing

The testing framework is [XUnit](https://xunit.github.io/). Just a matter of preference.

The assertion library [Shouldly](https://github.com/shouldly/shouldly) is used to make the tests a bit easier to reason and the failure message will be generate a friendlier message.

Testing the solution requires a higher level of sophistication. To handle this, the [Moq](https://github.com/moq/moq4) mocking framework has been used instead of fakes and spies.
