# Ratelimit

Every API has a ratelimit to protect the server from to many requests, which could lead to fatal errors. Simply said, its "what you pay is what you get". And we didnt pay anything, so we also didnt really get much. We were limited to 100 request in 24 hours. This is actually really easy to hit, as we noticed in development. So we couldnt fetch the weather-information everytime the user wanted to know it. We decided it would be good to cache the weather, to be able to access it as often as we want. We decided to mark the information as _old_ when it passes 30 minutes since we fetched it.

## Requirements

* File shouldn't just float around (add programfolder)
* All of the received information has to be saved


[Back to the overview](./Index.md)

