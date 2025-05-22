<h3>🌿 Leafline API</h3>
Leafline provides a RESTful API that enables developers to integrate dispensary data, product listings, and reviews into their apps or services.

<h3>Base URL</h3>
https://api.leafline.app/v1/

<h3>🔐 Authentication</h3>
All API requests require a valid API key.
<br/>
<br/>
Header:
<br/>
Authorization: Bearer YOUR_API_KEY


<br/>
<br/>

<h3>📘 Available Endpoints</h3>
<h2>GET /Dispensaries</h2>
<p>Provides a list of all dispensary unique identifiers within the Leafline API</p>
<h2>GET /Dispensary/{id}</h2>
<p>Returns the LeaflineDispensary object with the requested dispensary unique identifier.</p>
<h2>POST /Dispensary/create</h2>
<p>Accepts JSON serialized LeaflineDispensary objects to create a new database entry.</p>
