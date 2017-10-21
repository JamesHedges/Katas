Complex Object Oriented FunBooksAndVideo Solution
================================================

Motivation
==========
==========

When initially solving the FunBooksAndVideo problem, the decision was made to keep it simple and not "over engineer" the solution. This was done with the assumption that all items would be processed based on their ItemLineType. When presented with a business rule that invalidated this assumption, it became painfully obvious that the simple solution was not viable.

You may find the simple solution at [GitHub](https://github.com/JamesHedges/Katas/tree/master/FunBooksAndVideos/SimpleOO)

To further generalize the solution, it was decided to take a Domain Driven Design approach. Note that this was the original solution that was deemed "over engineered." With this approach, using domain event will be able to handle the various item processing business rule specifications.

