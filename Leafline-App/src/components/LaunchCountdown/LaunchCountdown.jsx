import { useEffect, useState } from "react";

const LaunchCountdown = () => {
    const launchDate = new Date("2025-06-01T00:00:00Z"); // Change this to your real launch date
    const [timeLeft, setTimeLeft] = useState(getTimeLeft());

    function getTimeLeft() {
        const now = new Date();
        const difference = launchDate - now;
        const time = {
            days: Math.floor(difference / (1000 * 60 * 60 * 24)),
            hours: Math.floor((difference / (1000 * 60 * 60)) % 24),
            minutes: Math.floor((difference / 1000 / 60) % 60),
            seconds: Math.floor((difference / 1000) % 60),
        };
        return time;
    }

    useEffect(() => {
        const timer = setInterval(() => {
            setTimeLeft(getTimeLeft());
        }, 1000);
        return () => clearInterval(timer);
    }, []);

    return (
        <div className="min-h-screen flex flex-col items-center justify-center bg-gradient-to-br from-green-200 to-green-500 text-white text-center px-4">
            <h1 className="text-4xl sm:text-6xl font-bold mb-4">Welcome to Leafline.</h1>
            <p className="text-lg sm:text-2xl mb-8 italic">Let's grow something great together</p>

            <div className="flex space-x-4 text-2xl sm:text-4xl font-mono">
                <TimeBox label="Days" value={timeLeft.days} />
                <TimeBox label="Hours" value={timeLeft.hours} />
                <TimeBox label="Minutes" value={timeLeft.minutes} />
                <TimeBox label="Seconds" value={timeLeft.seconds} />
            </div>
        </div>
    );
};

const TimeBox = ({ label, value }) => (
    <div className="flex flex-col items-center bg-white bg-opacity-20 px-4 py-2 rounded-xl shadow-lg">
        <div className="font-bold">{value.toString().padStart(2, "0")}</div>
        <div className="text-sm">{label}</div>
    </div>
);

export default LaunchCountdown;