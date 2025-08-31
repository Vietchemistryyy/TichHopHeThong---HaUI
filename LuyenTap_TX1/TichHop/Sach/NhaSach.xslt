<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:ns="http://tempuri.org/NhaSach.xsd"
	exclude-result-prefixes="ns"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
		<html>
			<head>
				<title>Nhà sách</title>
				<style>
					h4{
						margin-left: 260px;
						text-transform: uppercase;
					}
					table{
						border: 1px solid black;
						border-collapse: collapse;
						width: 600px;	
						margin: 0 auto;
						padding: 16px;
					}
					th, td{
						text-align: center;
					}
				</style>
			</head>
			<body>
				<h4>Nhà sách</h4>
				<table border="1">
					<tr>
						<th>STT</th>
						<th>Mã sách</th>
						<th>Tên sách</th>
						<th>Số trang</th>
						<th>Tác giả</th>
						<th>Giá tiền</th>
					</tr>
					<xsl:for-each select="ns:nhasach/ns:cuonsach">
						<xsl:sort data-type="number" order="descending" select="ns:sotrang"/>
						<tr>
							<td>
								<xsl:value-of select="position()"/>
							</td>
							<td>
								<xsl:value-of select="ns:masach"/>
							</td>
							<td>
								<xsl:value-of select="ns:tensach"/>
							</td>
							<td>
								<xsl:value-of select="ns:sotrang"/>
							</td>
							<td>
								<xsl:value-of select="ns:tacgia/ns:hoten"/>
							</td>
							<td>
								<xsl:variable name="trang" select="ns:sotrang"></xsl:variable>
								<xsl:variable name="thanhtien">
									<xsl:choose>
										<xsl:when test="$trang &gt;= 200">
											<xsl:value-of select="700 * $trang"/>
										</xsl:when>
										<xsl:otherwise>
											<xsl:value-of select="1000 * $trang"/>
										</xsl:otherwise>
									</xsl:choose>
								</xsl:variable>
								<xsl:value-of select="$thanhtien"/>
							</td>		
						</tr>	
					</xsl:for-each>
				</table>
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>
