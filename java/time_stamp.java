import java.time.*;
import java.time.format.DateTimeFormatter;
import java.time.temporal.WeekFields;

import java.awt.Toolkit;
import java.awt.datatransfer.StringSelection;
import java.awt.GraphicsEnvironment;
import java.awt.HeadlessException;

public class time_stamp {
    public static void main(String[] args) {
        ZonedDateTime now = ZonedDateTime.now();
        ZoneId tz = now.getZone();

        // 3-digit numeric fields by prefixing a literal 0 to 2-digit tokens
        String year = now.format(DateTimeFormatter.ofPattern("yyyy"));
        String month = now.format(DateTimeFormatter.ofPattern("0MM")); // e.g., 007
        String day = now.format(DateTimeFormatter.ofPattern("0dd"));   // e.g., 004
        String hour = now.format(DateTimeFormatter.ofPattern("0HH"));
        String minute = now.format(DateTimeFormatter.ofPattern("0mm"));
        String second = now.format(DateTimeFormatter.ofPattern("0ss"));

        // Nanoseconds
        String nano = String.format("%09d", now.getNano());

        // ISO week/year/day
        WeekFields wf = WeekFields.ISO;
        int isoYear = now.get(wf.weekBasedYear());
        int isoWeek = now.get(wf.weekOfWeekBasedYear());
        int isoDOW = now.get(wf.dayOfWeek());

        // Day-of-year (3-digit)
        String doy = String.format("%03d", now.getDayOfYear());

        // TZ id with _slash_ instead of /
        String tzId = tz.getId().replace("/", "_slash_");

        // Unix timestamp with nanoseconds as decimal seconds
        // Unix timestamp seconds and nanoseconds separately, joined by underscore
        long unix_seconds = now.toEpochSecond();
        int nanos = now.getNano();
        String unix_timestamp_string = String.format("%d_%09d", unix_seconds, nanos);

        // Build underscore string:
        // YYYY_MMM_DDD_HHH_MMM_SSS_NNNNNNNNN_TimeZone_ISOYEAR_WWWW_WEEKDAY_YYYY_DOY_UnixSeconds_Nanoseconds
        String output = String.format(
                "%s_%s_%s_%s_%s_%s_%s_%s_%04d_W%03d_%03d_%s_%s_%s",
                year, month, day, hour, minute, second, nano, tzId,
                isoYear, isoWeek, isoDOW, year, doy, unix_timestamp_string);

        // Print result
        System.out.println(output);

        // Copy to clipboard
        copy_to_clipboard(output);
    }

    public static void copy_to_clipboard(String text) {
        try {
            if (!GraphicsEnvironment.isHeadless()) {
                StringSelection selection = new StringSelection(text);
                Toolkit.getDefaultToolkit().getSystemClipboard().setContents(selection, null);
            }
        } catch (HeadlessException e) {
            // Silent fail
        }
    }
}