import http from 'k6/http';
import { sleep } from 'k6';
import { check } from 'k6';

// Define options for the load test (e.g., duration, virtual users) 
export let options = {
    stages: [
        { duration: '30s', target: 20 }, // Ramp up to 20 virtual users over 30 seconds
        { duration: '1m', target: 20 },  // Hold 20 users for 1 minute
        { duration: '30s', target: 0 },  // Ramp down to 0 users
    ],
};

export default function () {
    // Example of making a GET request to your backend API
    let res = http.get('http://localhost:5081/api/curs');
    
    // Check if the response status is 200 OK
    check(res, {
        'status is 200': (r) => r.status === 200,
    });

    // Simulate user think time (sleep for 1 second)
    sleep(1);
}
