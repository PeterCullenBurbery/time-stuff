"""
Date/time utility functions with clipboard copy
"""

from datetime import datetime
from zoneinfo import ZoneInfo
import tzlocal
import time
import pyperclip

def get_timestamp() -> str:
    # Local TZ and now with nanoseconds
    local_tz: ZoneInfo = tzlocal.get_localzone()
    ns_since_epoch: int = time.time_ns()
    seconds_since_epoch: int = ns_since_epoch // 1_000_000_000
    nanos_part: int = ns_since_epoch % 1_000_000_000
    now: datetime = datetime.fromtimestamp(seconds_since_epoch, tz=ZoneInfo(local_tz.key))

    # Components
    year: str = f"{now.year}"
    month: str = f"{now.month:03d}"
    day: str = f"{now.day:03d}"
    hour: str = f"{now.hour:03d}"
    minute: str = f"{now.minute:03d}"
    second: str = f"{now.second:03d}"
    nanoseconds: str = f"{nanos_part:09d}"
    time_zone: str = local_tz.key.replace("/", "_slash_")

    # ISO week info and ordinal day
    iso_year, iso_week, iso_weekday = now.isocalendar()
    iso_week_str: str = f"{iso_week:03d}"
    iso_weekday_str: str = f"{iso_weekday:03d}"
    day_of_year: str = f"{now.timetuple().tm_yday:03d}"

    return (
        f"{year}_{month}_{day}_{hour}_{minute}_{second}_"
        f"{nanoseconds}_{time_zone}_{iso_year:04d}_W{iso_week_str}_{iso_weekday_str}_"
        f"{year}_{day_of_year}_{seconds_since_epoch}_{nanoseconds}"
    )


if __name__ == "__main__":
    timestamp = get_timestamp()
    print(timestamp)

    # Copy to clipboard silently
    pyperclip.copy(timestamp)