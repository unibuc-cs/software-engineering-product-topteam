import http from 'k6/http';
import { sleep, check } from 'k6';

export let options = {
    scenarios: {
        soak_test: {
            executor: 'ramping-vus',
            startVUs: 0,
            stages: [
                { duration: '10m', target: 100 },
                { duration: '1h', target: 100 },  
                { duration: '10m', target: 0 },   
            ],
            gracefulStop: '30s',
        },
    },
};

export default function () {
    let res = http.get('http://localhost:5081/api/curs');

    check(res, {
        'status is 200': (r) => r.status === 200,
    });

    sleep(1);
}
