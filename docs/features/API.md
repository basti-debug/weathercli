# Querying the API

For forecasting weather, information needs to be analyzed and presented to the user. The information is obtained by querying an API (**A**pplication-**P**rogramming-**I**nterface). The API receives the location and some additional parameters (eg. forecast length) and sends back the desired information which is then decomposed

## Requirements

* API has to accept location as coordinates and town/country

## Additional Information

Every API has so called _"rate-limits"_, which determine the rate at which the information can be fetched, per time. In our case we are allowed to query 100 time per 24hrs. This was actually so big of a problem that we had to spend a lot of time to not hit our rate-limit. [Further information](./Ratelimit.md)

---

[Back to the overview](./Index.md)

