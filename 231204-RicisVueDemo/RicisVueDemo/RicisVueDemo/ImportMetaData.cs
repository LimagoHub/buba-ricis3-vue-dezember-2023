using System.Collections.Generic;
using System;

namespace RicisVueDemo
{
    public class ImportMetaData
    {
        /// <summary>
        /// Betrachtungstag der enthaltenen Daten
        /// </summary>
        public DateTime Betrachtungstag { get; set; }

        /// <summary>
        /// Name der zu Grunde liegenden Eingabedatei
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Zeitstempel des Imports (NICHT Importlaufs)
        /// </summary>
        public DateTime TimeGenerated { get; set; }

        /// <summary>
        /// Zu Grunde liegender Import-UseCase
        /// </summary>
        public string UseCase { get; set; }

        /// <summary>
        /// Enthält für jedes Alertlevel die Anzahl der in diesem Import aufgetretenen Alerts.
        /// </summary>
        /// <param name=""></param>
        public IDictionary<string, string> AlertTypesAndNoOfAlerts { get; set; }

        /// <summary>
        /// Gibt an, ob für den angegebenen Import Alerts vorliegen.
        /// </summary>
        /// <param name=""></param>
        public bool HasAlerts { get; set; }

        /// <summary>
        /// Gibt an, ob für den angegebenen Import Fehler vorliegen.
        /// </summary>
        /// <param name=""></param>
        public bool HasErrors { get; set; }

        /// <summary>
        /// Gibt an, ob für den angegebenen Import Warnungen vorliegen.
        /// </summary>
        /// <param name=""></param>
        public bool HasWarnings { get; set; }

        /// <summary>
        /// Gibt an, ob für den angegebenen Import Infos vorliegen.
        /// </summary>
        /// <param name=""></param>
        public bool HasInfos { get; set; }

        /// <summary>
        /// Gibt an, ob der Import in RICIS persistiert wurde.
        /// </summary>
        /// <param name=""></param>
        public bool IsPersistedToRicis { get; set; }

        /// <summary>
        /// Gibt an, ob für diesen Import Warnungen ignoriert wurden.
        /// </summary>
        /// <param name=""></param>
        public bool HasWarningsIgnored { get; set; }

        /// <summary>
        /// Zugrunde liegende RICIS-Instanz 
        /// </summary>
        /// <param name=""></param>
        //public RicisInstance RicisInstance { get; set; }
        public string RicisInstance { get; set; }

        /// <summary>
        /// Geworfene Exceptions zu einem Importlauf (sofern vorhanden) 
        /// </summary>
        /// <param name=""></param>
        public IDictionary<string, string> JobInfos { get; set; }

        /// <summary>
        /// Status mit dem die einzelnen Steps jeweils abgeschlossen wurden. 
        /// </summary>
        /// <param name=""></param>
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Import-Informationen auf Ebene der Archivdatei. 
        /// </summary>
        /// <param name=""></param>
        public string ExceptionInfo { get; set; }

        /// <summary>
        /// Indikator, von wem der Import initiiert wurde. 
        /// </summary>
        /// <param name=""></param>
        public string InitiatedBy { get; set; }

        /// <summary>
        /// Indikator, von wem der Import initiiert wurde. 
        /// </summary>
        /// <param name=""></param>
        public bool HasCsvReaderException { get; set; }

        /// <summary>
        /// Indikator, von wem der Import initiiert wurde. 
        /// </summary>
        /// <param name=""></param>
        public bool HasTechnicalException { get; set; }

        public IList<string> ExceptionInfos { get; set; }

        public IList<string> Statistics { get; set; }

        public IList<string> AlertMessages { get; set; }

        public bool ShowDataButton { get; set; }
    }
}
