<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
		exclude-result-prefixes="ns"
		xmlns:ns="http://tempuri.org/BenhVien.xsd"
	>
		<xsl:output method="html" indent="yes"/>

		<xsl:template match="/">
			<html>
				<head>
					<title>Bệnh viện đa khoa</title>
					<style>
						.container{
							width: 700px;
							border: 1px solid black;
							padding: 16px;
							margin: 0 auto;
							margin-bottom: 32px;
						}
						p{
							margin-right: 64px;
							margin-bottom: 8px;
						}
						b{
							margin-left: 80px;
							margin-bottom: 8px;
						}
					
					</style>
				</head>
				<body>
					<xsl:for-each  select="ns:BVDK/ns:Khoa">
						<div class="container">
							<table>
								<tr>
									<td>
										<p>BỆNH VIỆN ĐA KHOA</p>
									</td>
									<td>
										<b>DANH SÁCH BỆNH NHÂN</b>
									</td>
								</tr>
								<tr>
									<td>Khoa: <xsl:value-of select="ns:TenKhoa"/>
								</td>
									<td>
										Phòng: <xsl:value-of select="ns:Phong"/>
									</td>
								</tr>
							</table>
							<table border ="1" cellspacing="1">
								<tr>
									<th>Mã số BN</th>
									<th>Họ tên</th>
									<th>Ngày nhập viện</th>
									<th>Số ngày điều trị</th>
									<th>Số tiền phải trả</th>
								</tr>
								<xsl:for-each select="ns:BenhNhan">
									<tr>
										<td>
											<xsl:value-of select="@MasoBN"/>
										</td>
										<td>
											<xsl:value-of select="ns:HoTen"/>
										</td>
										<td>
											<xsl:value-of select="ns:NgayNhapVien"/>
										</td>
										<td>
											<xsl:value-of select="ns:NgayDieuTri"/>
										</td>
										<td>
											<xsl:variable name="songay" select="ns:NgayDieuTri"></xsl:variable>
											<xsl:variable name="dongia" select="15000"></xsl:variable>
											<xsl:variable name="giamgia">
												<xsl:choose>
													<xsl:when test="$songay &gt;= 15">0.15</xsl:when>
													<xsl:when test="$songay &gt;= 30">0.2</xsl:when>
													<xsl:when test="$songay &gt;= 90">0.25</xsl:when>
													<xsl:when test="$songay &lt; 7">0</xsl:when>
													<xsl:otherwise>0</xsl:otherwise>
												</xsl:choose>
											</xsl:variable>
											<xsl:variable name="thanhtien" select="$songay * $dongia * (1 - $giamgia)"></xsl:variable>
											<xsl:value-of select="$thanhtien"/>
										</td>
									</tr>
								</xsl:for-each>
							</table>
						</div>
					</xsl:for-each>
				</body>
			</html>
		</xsl:template>
	</xsl:stylesheet>
