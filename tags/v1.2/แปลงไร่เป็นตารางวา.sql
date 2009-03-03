SELECT     D.Q_ID, D.Coll_ID,Left(D.Coll_ID,2)as CollType, ISNULL(CD.Detail1, '-') AS Detail1, CD.PROV_NAME, ISNULL(CD.Detail2, '-') AS Detail2, CD.RAI, CD.NGAN, CD.WAH
FROM         Sent_Appraisal_Detail AS D INNER JOIN
                      Bay01.dbo.COLL_ID_DISTINCT AS CD ON D.Coll_ID = CD.COLL_ID AND D.Cif = CD.CIF
WHERE     (D.PreAID = 102) AND (D.Q_ID = 1)


SELECT D.PREAID,Left(D.Coll_ID,2)AS CollType,sum(rai*400)+sum(ngan*100)+sum(wah)as Totalwah,
	   FLOOR((sum(rai*400)+sum(ngan*100)+sum(wah))/400)as Rai,
	    FLOOR(((sum(rai*400)+sum(ngan*100)+sum(wah))- (FLOOR((sum(rai*400)+sum(ngan*100)+sum(wah))/400))*400)/100)as Ngan,
	    ((((sum(rai*400)+sum(ngan*100)+sum(wah))- (FLOOR((sum(rai*400)+sum(ngan*100)+sum(wah))/400))*400)/100)-( FLOOR(((sum(rai*400)+sum(ngan*100)+sum(wah))- (FLOOR((sum(rai*400)+sum(ngan*100)+sum(wah))/400))*400)/100)))*100 as Wah,
	    sum(SQUAREMATE)AS SQUAREMATE,Count(MACH_NO)MACH_NO
FROM         Sent_Appraisal_Detail AS D INNER JOIN
                      Bay01.dbo.COLL_ID_DISTINCT AS CD ON D.Coll_ID = CD.COLL_ID AND D.Cif = CD.CIF
WHERE     (D.PreAID = 102) AND (D.Q_ID = 1)
Group by PREAID,Left(D.Coll_ID,2)

SELECT     D.Q_ID, LEFT(D.Coll_ID, 2) AS CollType
FROM         Sent_Appraisal_Detail AS D INNER JOIN
                      CollType AS C ON LEFT(D.Coll_ID, 1) = C.CollType_ID
WHERE     (D.PreAID = 102) AND (D.Q_ID = 1)
group by  D.Q_ID,LEFT(D.Coll_ID, 2)
