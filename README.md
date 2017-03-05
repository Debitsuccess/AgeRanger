I ran out of time before I got to the front end (I lost a chunk of time fighting with my old SQL Server install trying to get it to work again), which I am disapointed about.

I did complete a WebApi backend however, with unit tests, using .Net Core, and manually tested it using PostMan in Chrome.

I used in-memory repositories to test with, with the goal to swap them out for real ones matching the same interface later.
These lock correctly, but the checks for concurrent modification are in the layer before the in-memory part so apply to real repo layers too.

Unit test around the created dates etc are possible due to the use of the `Current` class in `Tools`.
