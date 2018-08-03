BCP "SELECT value,PronouncesUs,'\"'+REPLACE(Sample,'\"','\"\"')+'\"' Sample,'\"'+REPLACE(Phrase,'\"','\"\"')+'\"' Phrase,'\"'+REPLACE(Detail,'\"','\"\"')+'\"' Detail,'\"'+REPLACE(PronouncesEn,'\"','\"\"')+'\"' PronouncesEn,'\"'+REPLACE(DetailEnEn,'\"','\"\"')+'\"' DetailEnEn,'\"'+REPLACE(Synant,'\"','\"\"')+'\"' Synant,'\"'+REPLACE(Inflections,'\"','\"\"')+'\"' Inflections,AudioUrl,Audio,Mark,UpdateCount,UpdateTime FROM WORD_EN" queryout WORD_EN.csv -n -S153.59.64.177 -Usa -Pncrsa_ora


bcp CTest.dbo.WORD_EN in WORD_EN.csv -n -S153.59.64.177 -Usa -Pncrsa_ora