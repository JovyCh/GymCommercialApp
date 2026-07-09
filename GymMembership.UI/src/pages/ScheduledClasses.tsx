import { useScheduledClasses } from "../hooks/useScheduledClasses"

export default function ScheduledClasses(){
    const {scheduledClasses} = useScheduledClasses();
        return (
            <div style={{ padding: '20px', fontFamily: 'sans-serif' }}>
                <h2>Scheduled Classes</h2>

                <ul>
                    {scheduledClasses.map(scheduledClasses => (
                    <li key={scheduledClasses.id}>
                        <span>{scheduledClasses.name} ({scheduledClasses.description})</span>
                    </li>
                    ))}
                </ul>
            </div>
    )
}